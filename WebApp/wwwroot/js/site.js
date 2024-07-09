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
    console.log("chamou");
    var navProj = document.getElementById("navProjetos");
    var navConta = document.getElementById("navConta");
    var navLogin = document.getElementById("navLogin");
    var navSair = document.getElementById("navSair");

    if (go !== 0)
    {
        navProj.classList.remove("d-none");
        navSair.classList.remove("d-none");
        navConta.classList.add("d-none");
        navLogin.classList.add("d-none");
    }
    else
    {
        navProj.classList.add("d-none");
        navSair.classList.add("d-none");
        navConta.classList.remove("d-none");
        navLogin.classList.remove("d-none");
    }
}