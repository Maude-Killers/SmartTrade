function getJWTTokenCookie() {
    var value = `; ${document.cookie}`;
    var parts = value.split(`; JWTToken=`);
    if (parts.length === 2) return parts.pop().split(';').shift();
    return null; // Si no se encuentra la cookie, devuelve null
}