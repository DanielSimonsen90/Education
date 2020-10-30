var TSCalculator = /** @class */ (function () {
    function TSCalculator() {
        this.Start = '';
        this.End = '';
        this.Operator = '';
        this.UsingStart = true;
    }
    /** Handles NumberButton events*/
    TSCalculator.prototype.HandleNumber = function (num) {
        try {
            if (this.UsingStart)
                this.Start += num;
            else
                this.End += num;
            console.log("HandleNumber('" + num + "') was called.");
        }
        catch (error) {
            console.log(error);
        }
    };
    /** Handles Operator events */
    TSCalculator.prototype.HandleOperator = function (operator) {
        try {
            this.UsingStart = this.UsingStart ? false : true;
            if (operator != '=') {
                this.Operator = operator;
                return console.log("HandleOperator'(" + operator + "') was called.");
            }
            this.End = this.Calculate().toString();
            this.Start = '';
            this.Operator = '';
            console.log("HandleOperator('" + operator + "') was called, returned " + this.End);
        }
        catch (error) {
            console.log(error);
        }
    };
    /**Calculates equation */
    TSCalculator.prototype.Calculate = function () {
        var numStart = parseInt(this.Start), numEnd = parseInt(this.End);
        switch (this.Operator) {
            case '+': return numStart + numEnd;
            case '-': return numStart - numEnd;
            case '*': return numStart * numEnd;
            case '/': return numStart / numEnd;
            case '^': return Math.round(Math.pow(numStart, numEnd));
            default: return numStart;
        }
    };
    return TSCalculator;
}());
var Operators = ["plus", "minus", "multiply", "divide", "power", "equals"], OperatorSymbols = ["+", "-", "*", "/", "^", "="], ButtonNames = ["Clear"];
//# sourceMappingURL=Calculator.js.map