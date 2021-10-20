/**
 * @typedef Login
 * @type {{ username: string, password: string }}
 */

/**@returns {Login} */
function getDetails() {
    /**@type {string[]} */
    const [username, password] = ["username", "password"].map(id => document.querySelector(`#${id}`)?.value);
    if (!username || !password) {
        alert("No username or password provided");
        return null;
    }

    return { username, password: stringToHash(password) };
}
/**@param {string} value */
function stringToHash(value) {
    let hash = 0;
      
    if (!value.length) return hash;
      
    for (i = 0; i < value.length; i++) {
        char = value.charCodeAt(i);
        hash = ((hash << 5) - hash) + char;
        hash = hash & hash;
    }
      
    return hash;
}

/**@returns {Login[]} */
function getLogins() {
    const loginsJson = localStorage.getItem("logins");
    return loginsJson?.length ? JSON.parse(loginsJson) : [];
}
/**@param {Login} login */
function updateWith(login) {
    localStorage.setItem("logins", JSON.stringify([...getLogins(), login]));
}

function onLogin() {
    const login = getDetails();
    if (!login) return;

    const isValid = getLogins().find(l => l.username == login.username && l.password == login.password);
    alert(isValid ? `Welcome back, ${login.username}!` : `Invalid username or password!`);
}
function onSignUp() {
    const login = getDetails();
    if (!login) return;

    const logins = getLogins();
    const hasUsername = logins.find(l => l.username == login.username);
    if (hasUsername) {
        return hasUsername.password == login.password ? onLogin() : null;
    }

    updateWith(login);

    alert(`${login.username} registered`);
}

