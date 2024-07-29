function RegisterToken() {
    let obj = {
        email: document.getElementById('Login').value,
        password: document.getElementById('Passwod').value
    }
    let tokenkey = "accessToken"
    $.ajax({
        url: "/LoginIn",
        method:"POST",
        dataType: "json",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(obj),
        success: function (result) {
            sessionStorage.setItem(tokenkey, result);
        }
    });
    
}
function Index() {
    $.ajax({
        url: "/Home/Index",
        method: "GET",
        dataType: "json",
        contentType: "application/json;charset=UTF-8",
    })
}