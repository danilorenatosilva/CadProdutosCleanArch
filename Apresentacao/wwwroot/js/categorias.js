
window.onload = function () {

    function carregaCategorias() {

        $.ajax({
            type: "GET",
            url: "https://localhost:44320/api/categorias",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                $("#conteudo").html('');
                let html = "<div class='row'>";
                $.each(data, function (i, item) {
                    html += "<div class='col-md-3 card'>" +
                        "<img src='" + item.urlImagem + "' />" +
                        "<span class='card-footer'>" + item.nome + "</span>" +
                        "</div>";
                });
                html += "</div>";
                $("#conteudo").append(html);
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

    function serializaFormulario(form) {
        let objeto = {};
        let campos = form.elements;
        alert(campos);
        for (let i = 0; i < campos.length; i++) {
            if (campos[i] && campos[i].name) {
                let key = campos[i].name;
                objeto[key] = campos[i].value;
            }
        }
        return objeto;
    }

    function carregaFormCategoria() {
        $("#conteudo").html('');
        let html = "<h2>Adicionar Nova Categoria</h2>" +
            "<form id='formCategoria'>" +
            "<div class='form-group'>" +
            "<label for='nome'>Nome</label>" +
            "<input type='text' name='nome' class='form-control' />" +
            "</div>" +
            "<div class='form-group'>" +
            "<label for='nome'>Descricao</label>" +
            "<textarea name='descricao' class='form-control' rows='4'></textarea>" +
            "</div>" +
            "<div class='form-group'>" +
            "<label for='urlImagem'>Imagem</label>" +
            "<input type='file' class='form-control-file' name='urlImagem'>" +
            "</div>" +
            "<button type='submit' class='btn btn-primary'>Salvar</button>" +
            "</form>";
        $("#conteudo").html(html);

        $('#formCategoria').on('submit', (function (e) {
            e.preventDefault()            
            $.ajax({
                type: 'POST',
                contentType: "application/json; charset=utf-8",
                url: "https://localhost:44320/api/categorias",
                data: JSON.stringify(serializaFormulario(this)),
                cache: false
            });
        }));
    }

    let btnAdicionar = document.getElementById("adicionarCategoria");
    btnAdicionar.onclick = function () {
        carregaFormCategoria();
    };

}