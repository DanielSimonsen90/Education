/**Loads the respective page?
 * @param {string} Language @param {boolean} isCalculatorPage*/
function LoadPage(Language, isCalculatorPage) {
    document.title = `:[ ${Language} Lommeregner ]: | Daniel Simonsen's Lommeregnere`;

    LoadBodyContent(Language, isCalculatorPage);
}

/**Sets the body content of the page
 * @param {string} Language @param {boolean} isCalculatorPage*/
function LoadBodyContent(Language, isCalculatorPage) {
    LoadNavBar(isCalculatorPage);

    document.write(`<h1>${Language} Lommeregner</h1>`);
    document.write(`<h3>Begynd du bare at regne!</h3>`);
    document.write(`<div class="CalculatorContainer">`);
    document.write(`<input class="Display" type="text" placeholder="Hvad skal vi regne ud?">`);
    LoadButtons(GetIndexName(Language));
    document.write(`</div>`);
}
/**Loads the Navigation bar
 * @param {boolean} isCalculatorPage*/
function LoadNavBar(isCalculatorPage) {
    const Links = isCalculatorPage ? [
        `<a href="JavaScript.html">JavaScript</a>`,
        `<a href="JQPage.html">jQuery</a>`,
        `<a href="TSPage.html">TypeScript</a>` 
    ] : [
        `<a href="Pages/CalculatorPages/JavaScript.html">JavaScript</a>`,
        `<a href="Pages/CalculatorPages/JQPage.html">jQuery</a>`,
        `<a href="Pages/CalculatorPages/TSPage.html">TypeScript</a>`
    ];

    document.write(`<div class="NavBar">`)
    document.write(`<a href="../../index.html"><img src="/logo.png"/></a>`);
    document.write(`<span class="NavBarContent">`);
    for (var i = 0; i < Links.length; i++)
        document.write(Links[i]);
    document.write(`</span>`);
    document.write(`</div>`);
}

/**Returns the indexName of Language
 * @param {string} Language*/
function GetIndexName(Language) {
    switch (Language) {
        case "JavaScript": return "JSIndex";
        case "jQuery": return "JQIndex";
        case "TypeScript": return "TSIndex";
        default: return Language;
    }
}

/**Loads the buttons of the page
 * @param {string} indexName*/
function LoadButtons(indexName) {
    const classes = ["MiscButtonContainer", "NumberButtonContainer", "OperatorButtonContainer"],
        methods = ["GetMiscTags()", "GetNumberTags()", "GetOperatorTags()"];

    for (var i = 0; i < 3; i++) {
        document.write(`<div class="${classes[i]}">`);
        document.write(`<script>${indexName}.${methods[i]};</script>`);
        document.write(`</div>`);
    }
}