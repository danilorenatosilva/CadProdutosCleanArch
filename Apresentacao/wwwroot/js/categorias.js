
window.onload = function () {

    function carregaCategorias() {

        $.ajax({
            type: "GET",
            url: "https://localhost:44320/api/categorias",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                console.log(data);
                $("#container").html('');
                let html = "<div class='row'>";
                $.each(data, function (i, item) {
                    html += "<div class='col-md-3 card'>" +
                        "<img src='" + item.urlImagem + "' />" +
                        "<span class='card-footer'>" + item.nome + "</span>" +
                        "</div>";
                });
                html += "</div>";
                console.log(html);
                $("#container").append(html);
            },
            failure: function (data) {
                alert("failure");
            },
            error: function (data) {
                alert("error");
            }
        });
    }

    carregaCategorias();

}