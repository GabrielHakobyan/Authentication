function RegisterToken() {
    let obj = {
        email: document.getElementById('Login').value,
        password: document.getElementById('Passwod').value
    }
    let tokenkey = "accessToken"
    $.ajax({
        url: "/Home/LoginIn",
        method:"POST",
        dataType: "json",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(obj),
        success: function (result) {
            sessionStorage.setItem(tokenkey, result.access_token);
            console.log(result.access_token);
        }
    });
    
}
function Index() {
    var tokenkey = "accessToken";
    var token = sessionStorage.getItem(tokenkey);
    $.ajax({
        url: "/Home/Index",
        method: "GET",
        dataType: "json",
        contentType: "application/json;charset=UTF-8",
        headers: {
            "Accept": "application/json",
            "Authorization": "Bearer " + token  // передача токена в заголовке
        },
       
    });
}