
window.onload = function () {

    function carregaFormProduto(id) {

        let editando = id != undefined;

        $("#conteudo").html('');

        let caminhoFisicoImagens = document.getElementById('caminhoFisicoImagens').value;
        let titulo = editando ? "Editar Produto" : "Nova Produto";
        let metodoHttp = editando ? "PUT" : "POST";

        let html = "<h2>" + titulo + "</h2>" +
            "<form id='formProduto' enctype='multipart/form-data' method='post'>" +
            "<div class='form-group'>" +
            "<label for='nome'>Categoria</label>" +
            "<select type='text' name='IdCategoria' id='ddlCategoria' class='form-control' /> " +
            "</div>" +
            "<div class='form-group'>" +
            "<label for='nome'>Nome</label>" +
            "<input type='text' name='nome' id='nome' class='form-control' /> " +
            "</div>" +
            "<div class='form-group'>" +
            "<label for='nome'>Descricao</label>" +
            "<textarea name='descricao' id='descricao' class='form-control' rows='4'></textarea>" +
            "</div>" +
            "<div class='form-group'>" +
            "<label for='nome'>Preço Unitário</label>" +
            "<input type='number' name='precounitario' id='precounitario' class='form-control' />" +
            "</div>" +
            "<div class='form-group'>" +
            "<label for='urlImagem'>Imagem</label>" +
            "<input type='file' class='form-control-file' name='arquivoImagem' id='arquivoImagem' accept='image/*' />" +
            "</div>" +
            "<button type='submit' class='btn btn-primary'>Salvar</button>" +
            "<input type='hidden' name='caminhoFisicoImagens' value='" + caminhoFisicoImagens + "' />";

        if (editando) {
            html += "<input type='hidden' value='" + id + "' name='id' />";
        }

        html += "</form>";

        $("#conteudo").html(html);

        if (editando) {
            $.get("https://localhost:44320/api/produtos/" + id, function (data) {
                document.getElementById("nome").value = data.nome;
                document.getElementById("descricao").value = data.descricao;
                document.getElementById("precounitario").value = data.precounitario;
                document.getElementById("idcategoria").value = data.idcategoria;
            });
        }

        $('#formProduto').on('submit', (function (e) {
            e.preventDefault();

            let formData = new FormData(this);

            $.ajax({
                type: metodoHttp,
                url: "https://localhost:44320/api/produtos",
                data: formData,
                processData: false,
                contentType: false,
                success: function (data) {
                    carregaProdutos();
                },
                error: function (error) {
                    console.log(error.responseText);
                }
            });
        }));
    }

    function carregaProdutos() {

        $.ajax({
            type: "GET",
            url: "https://localhost:44320/api/produtos",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                $("#conteudo").html('');
                let html = "<div class='row'>";
                $.each(data, function (i, item) {
                    html += "<div class='col-md-3 card'>" +
                        "<img src='" + item.urlImagem + "' height='200' />" +
                        "<div class='botoes'>" +
                        "<a href='#' class='btn btn-info btn-lg editarProduto' id='editarProduto-" + item.id + "'>" +
                        "<span class='glyphicon'></span> Editar" +
                        "</a>" +
                        "<a href='#' class='btn btn-danger btn-lg deletarProduto' id='deletarProduto-" + item.id + "'>" +
                        "<span class='glyphicon'></span> Deletar" +
                        "</a>" +
                        "</div>" +
                        "<span class='card-footer'>" + item.nome + "</span>" +
                        "</div>";
                });
                html += "</div>";

                $("#conteudo").append(html);

                let botoesEdicao = document.getElementsByClassName('editarProduto');
                for (let i = 0; i < botoesEdicao.length; i++) {
                    botoesEdicao[i].onclick = function () {
                        let id = $(this).attr("id").split('-')[1];
                        carregaFormProduto(id);
                    };
                }

                let botoesDelecao = document.getElementsByClassName('deletarProduto');
                for (let i = 0; i < botoesDelecao.length; i++) {
                    botoesDelecao[i].onclick = function () {
                        let id = $(this).attr("id").split('-')[1];
                        let resposta = confirm("Tem certeza que deseja excluir esta produto?");
                        if (resposta) {
                            $.ajax({
                                type: "DELETE",
                                url: "https://localhost:44320/api/produtos/" + id,
                                success: function (data) {
                                    carregaProdutos();
                                },
                                error: function (error) {
                                    alert(error.responseText);
                                }
                            });
                        }
                    };
                }
            },
            failure: function (data) {
                alert("failure");
            },
            error: function (data) {
                alert("error");
            }
        });
    }

    carregaProdutos();

    let btnAdicionar = document.getElementById("adicionarProduto");
    btnAdicionar.onclick = function () {
        carregaFormProduto();
    };

}