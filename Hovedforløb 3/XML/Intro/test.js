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