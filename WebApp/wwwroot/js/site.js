function LimparNovaConta()
{
    var form = document.getElementById("formNovaConta");
    form.reset();
}

// Tentativa de criar um sistema manual de login, mas reconheci a
// dificuldade no meio do caminho. Ponderei sobre usar o
// authentication do próprio Razor, mas também desisti devido
// ao tempo.

/* var userId = 0;*/

function logOn(go)
{
    if (go)
    {
        var navProj = document.getElementById("navProjetos");
        var navConta = document.getElementById("navConta");
        var navSair = document.getElementById("navSair");

        navProj.className = "btn btn-outline-primary ms-2 me-2";
        navConta.className = "d-none btn btn-outline-primary ms-2 me-2";
        navSair.className = "btn btn-outline-primary ms-2 me-2";
        navLogin.className = "d-none btn btn-outline-primary ms-2 me-2";
    }
}