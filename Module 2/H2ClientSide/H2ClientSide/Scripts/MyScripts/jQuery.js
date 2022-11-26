class JQCalculator {
    constructor() {
        this.Start = '';
        this.End = '';
        this.Operator = '';
        this.UsingStart = true;
        this.isNegative = false;
    }

    /** Handles NumberButton events
     * @param {string} num*/
    HandleNumber(num) {
        try {
            if (this.isNegative) {
                if (this.UsingStart && this.Start == '') this.Start = `-${num}`;
                else if (this.UsingStart) this.Start += num;

                else if (!this.UsingStart && this.End == '') this.End = `-${num}`;
                else this.End += num;
            }
            else {
                if (this.UsingStart) this.Start += num;
                else this.End += num;
            }

            console.log(`HandleNumber('${num}') was called.`);
        } catch (error) { console.log(error); }
    }
    /** Handles Operator events
     * @param {'+' | '-' | '•' | '/' | '='} operator*/
    HandleOperator(operator) {
        if (operator != '-' && this.Start != '') {
            this.UsingStart = this.UsingStart ? false : true;
            this.isNegative = false;
        }

        if (operator != '=') {
            console.log(`HandleOperator('${operator}') was called.`);

            if (operator == '-')
                if (this.UsingStart && this.Start == '' || !this.UsingStart && this.End == '')
                    if (this.Operator = '') {
                        this.Operator = operator;
                        this.UsingStart = false;
                    }
                    else this.isNegative = true;

            console.log(`isNegative is true for ${this.UsingStart ? 'this.Start' : 'this.End'}`);
        }

        if (!this.isNegative && this.Start != '' && operator != '=') {
            this.Operator = operator == '•' ? '*' : operator;
            return;
        }

        if (operator != '=') return;

        this.Start = this.Calculate().toString();
        this.End = '';
        this.Operator = '';
        console.log(`HandleOperator('=') was called, returned ${this.Start}`);
    }
    /**Calculates equation */
    Calculate() {
        const numStart = parseInt(this.Start),
            numEnd = parseInt(this.End);
        if (!this.Operator)
            this.Operator = '+';

        switch (this.Operator) {
            case '+': return numStart + numEnd;
            case '-': return numStart - numEnd;
            case '*': return numStart * numEnd;
            case '/': return numStart / numEnd;
            case '^': return Math.round(Math.pow(numStart, numEnd));
            default: return numStart;
        }
    }
}
const Operators = ["plus", "minus", "multiply", "divide", "power", "equals"],
    OperatorSymbols = ["+", "-", "•", "/", "^", "="],
    ButtonNames = ["Clear"];

class jQueryIndex {
    constructor() {
        this.Calculator = new JQCalculator();
        this.DisplayLabel = null;
    }

    //#region Set tags
    /** Sets the Number Buttons*/
    GetNumberTags() {
        try {
            for (var i = 10 - 1; i >= 0; i--)
                $('.NumberButtonContainer').append(`<button name="btn${i}" class="NumberButton" onclick="JQIndex.OnButtonPressed('${i}')">${i}</button>`);
            console.log('Set Numbers');
        } catch (error) { console.log(error); }
    }
    /** Sets the Operator Buttons */
    GetOperatorTags() {
        try {
            for (var i = 0; i < Operators.length; i++)
                $('.OperatorButtonContainer').append(`<button name="${Operators[i]}" class="OperatorButton" onclick="JQIndex.OnButtonPressed('${OperatorSymbols[i]}')">${OperatorSymbols[i]}</button>`);
            console.log('Set Operators');
        } catch (error) { console.log(error); }
    }
    /** Sets the misc. buttons */
    GetMiscTags() {
        try {
            for (var i = 0; i < ButtonNames.length; i++)
                $('.MiscButtonContainer').append(`<button name="${ButtonNames[i]}" class="MiscButton" onclick="JQIndex.MiscButtonsPressed('${ButtonNames[i]}')">${ButtonNames[i]}</button>`);
            console.log('Set Misc');
        } catch (error) { console.log(error); }
    }
    //#endregion

    //#region ButtonPressed
    /** ButtonPress event for both Number & Operator buttons
     * @param {string} buttonName*/
    OnButtonPressed(buttonName) {
        if (!this.DisplayLabel) {
            this.DisplayLabel = {
                /**@returns {string} */
                getValue() { return $(".Display").val(); },
                /**@param {string} newValue*/
                setValue(newValue) { $(".Display").val(newValue); /*.html(newValue);*/ }
            };
            this.DisplayLabel.setValue('');
        }

        //#region Contains =
        if (this.DisplayLabel.getValue().includes('='))
            this.DisplayLabel.setValue(`${this.Calculator.Start} `);
        //#endregion

        //If buttonName is an operator, call HandleOperator() else call HandleNumber()
        if (OperatorSymbols.includes(buttonName)) {
            //Add buttonName value to Display textbox
            this.Calculator.HandleOperator(buttonName);
            if (!this.Calculator.isNegative)
                this.DisplayLabel.setValue(`${this.DisplayLabel.getValue()} ${buttonName} `);
            else this.DisplayLabel.setValue(`${this.DisplayLabel.getValue()}${buttonName}`);
        }
        else {
            //Add buttonName value to Display textbox
            this.DisplayLabel.setValue(this.DisplayLabel.getValue() + buttonName);
            this.Calculator.HandleNumber(buttonName);
        }

        //If = was pressed, return final calculation
        if (buttonName == "=")
            this.DisplayLabel.setValue(this.DisplayLabel.getValue() + this.Calculator.Start);

        console.log('--== Status ==--\n' +
            `UsingStart: ${this.Calculator.UsingStart}\n` +
            `isNegative: ${this.Calculator.isNegative}\n` +
            `Start: ${this.Calculator.Start}\n` +
            `Operator: ${this.Calculator.Operator}\n` +
            `End: ${this.Calculator.End}`);
    }
    /** ButtonPress event for Misc buttons.
    * @param {string} buttonName */
    MiscButtonsPressed(buttonName) {
        switch (buttonName) {
            case "Clear":
                this.Calculator = new JQCalculator();
                this.DisplayLabel.setValue("");
                this.DisplayLabel = null;
                console.clear();
                break;
            default: console.log(`MiscButtonsPressed(${buttonName}) called default case.`); break;
        }
        console.log(`MiscButtonsPressed(${buttonName}) was called.`);
    }
    //#endregion
}
const JQIndex = new jQueryIndex();