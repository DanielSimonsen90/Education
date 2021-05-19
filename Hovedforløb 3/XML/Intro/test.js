let buttonSorter;

function setSortingButton() {
    buttonSorter = document.getElementById('sorter');
    buttonSorter.onclick = () => {
        let sortings = ["name", "price"]; //All types of sortings
        let [template, currentSorting] = buttonSorter.innerText.split(':'); //Split content by : to get current sorting
        sortings.splice(sortings.indexOf(currentSorting.substring(1)), 1); //Filter current sorting out of sortings
        let sorting = sortings[Math.floor(Math.random() * sortings.length)] //Get random sorting
        buttonSorter.innerText = `${template}: ${sorting}`;
    }
}

function isName() {
    return buttonSorter.innerText.includes('name');
}

var xhttp = new XMLHttpRequest();
xhttp.onreadystatechange = onReadyStateChanged;

function onReadyStateChanged() {
    if (this.readyState == 4 && this.status == 200) {
        loadXML(this);
    }
}

function loadXML(xml) {
    let data = document.getElementById('data');
    data.innerText = "";
    data.classList.remove('default');
    data.classList.add('data');

    var xmlDoc = xml.responseXML;

    /** @param {Document} child */
    function createXMLElement(child) {
        let element = document.createProperElement('div', {
            classes: ['xmlElement'],
            attributes: [['id', child.nodeName]]
        });
        
        element.append(`${child.nodeName}`);
        
        if (child.attributes?.length) {
            element.append(': ');
            
            let attributes = [];
            for (const {name, value} of child.attributes) {
                attributes.push(`${name}: ${value}`);
            }
            element.append(attributes.join(' | '))
        }
        
        if (child.children.length) {
            for (const gChild of child.children) {
                element.append(createXMLElement(gChild));
            }
        }
        else element.innerText = child.textContent;
        
        return element;
    }

    let root = createXMLElement(xmlDoc.children[0]);
    console.log(root);
    data.append(root);
}

function onSubmit() {
    let fileElement = document.getElementById('inputFile');
    let file = fileElement.files[0];
    if (!fileElement.validity.valid || !file)
        return alert(`File must be an XML file!`);
    
    let data = document.getElementById('data');
    data.innerText = "Opening  your file...";


    xhttp.open('GET', fileElement.files[0].name, true);
    xhttp.send();
}