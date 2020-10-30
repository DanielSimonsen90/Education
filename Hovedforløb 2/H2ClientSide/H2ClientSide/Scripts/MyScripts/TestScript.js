const Operators = ["plus", "minus", "multiply", "divide", "power", "equals"],
    OperatorSymbols = ["+", "-", "•", "/", "^", "="],
    ButtonNames = ["Clear"];

class JavaScriptIndex {

    //#region Set tags
    /** Sets the Number Buttons*/
    GetNumberTags() {
        try {
            for (var i = 10 - 1; i >= 0; i--)
                document.write(`<button name="btn${i}" class="NumberButton" onclick="JSIndex.OnButtonPressed('${i}')">${i}</button>`);
            console.log('Set Numbers');
        } catch (error) { console.log(error); }
    }
    /** Sets the Operator Buttons */
    GetOperatorTags() {
        try {
            for (var i = 0; i < Operators.length; i++)
                document.write(`<button name="${Operators[i]}" class="OperatorButton" onclick="JSIndex.OnButtonPressed('${OperatorSymbols[i]}')">${OperatorSymbols[i]}</button>`);
            console.log('Set Operators')
        } catch (error) { console.log(error); }
    }
    /** Sets the misc. buttons */
    GetMiscTags() {
        try {
            for (var i = 0; i < ButtonNames.length; i++)
                document.write(`<button name="${ButtonNames[i]}" class="MiscButton" onclick="JSIndex.MiscButtonsPressed('${ButtonNames[i]}')">${ButtonNames[i]}</button>`);
            console.log('Set Misc');
        } catch (error) { console.log(error); }
    }
    //#endregion

    /** ButtonPress event for both Number & Operator buttons
     * @param {string} buttonName*/
    OnButtonPressed(buttonName) {
        //Set Display
        if (!this.DisplayLabel) {
            this.DisplayLabel = document.getElementsByClassName("Display")[0];
            this.DisplayLabel.value = "";
            console.log('Display was set to empty');
        }

        if (buttonName == '=')
            return this.DisplayLabel.value = this.ProcessEquation() + ' ';
        else if (buttonName != '-' && isNaN(parseInt(buttonName)))
            this.DisplayLabel.value += ` ${buttonName} `;
        else this.DisplayLabel.value += buttonName;
        console.log(`Called ${buttonName}`);
    }
    ProcessEquation() {
        var result = 0,
            equationLine = this.DisplayLabel.value.split(' ');
        console.log(equationLine);

        while (equationLine.length != 0) {
            const properties = GetProperties(result, equationLine);
            console.log(`Properties returned: ${properties[0]} ${properties[1]} ${properties[2]}`)
            result = GetResult(properties[0], properties[1], properties[2]);
            console.log(`Result is now ${result}`);
            console.log(properties);
        }
        return result;

        /**@param {number} result @param {string[]} equationLine*/
        function GetProperties(result, equationLine) {
            var properties = [];
            if (result != 0)
                properties[0] = result.toString();

            for (var index = properties[0] ? 1 : 0; !properties[2]; index++) {
                var property = equationLine.shift(); //Get element from array [a, o, b]
                if (properties[index]) //Property exists (contains -)
                    properties[index] += property; //Add new property onto property
                else if (property == '-' && index != 1) //if symbol and not operator
                    index--; //Subtract Index so a/b is number
                else
                    properties[index] = property; //Set property in properties[]
            }
            return properties;
        }

        /**@param {string} start
         * @param {string} operator
         * @param {string} end*/
        function GetResult(start, operator, end) {
            const a = parseInt(start),
                b = parseInt(end);
            switch (operator) {
                case '+': return a + b;
                case '-': return a - b;
                case '•': return a * b;
                case '/': return a / b;
                case '^': return Math.pow(a, b);
                case undefined: return 0;
                default: return -1;
            }
        }
    }
    /** ButtonPress event for Misc buttons.
    * @param {string} buttonName */
    MiscButtonsPressed(buttonName) {
        switch (buttonName) {
            case "Clear":
                this.DisplayLabel.value = "";
                this.DisplayLabel = null;
                console.clear();
                break;
            default: console.log(`MiscButtonsPressed(${buttonName}) called default case.`); return;
        }
        console.log(`MiscButtonsPressed(${buttonName}) was called.`);
    }
}
const JSIndex = new JavaScriptIndex();