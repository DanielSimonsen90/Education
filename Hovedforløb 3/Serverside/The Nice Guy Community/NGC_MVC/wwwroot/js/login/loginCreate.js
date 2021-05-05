function loginCreate() {
    let username = document.getElementById('username').value; //value of Username input
    let password = document.getElementById('password').value; //Value of Password input
    //Add /CreateLogin to current location to handle path change in C# with values from inputs
    window.location.href = document.location.toString() + `/CreateLogin?username=${username}&password=${password}`;
}