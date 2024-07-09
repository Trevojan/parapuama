const tooltipTriggerList = document.querySelectorAll('[data-bs-toggle="tooltip"]')
const tooltipList = [...tooltipTriggerList].map(tooltipTriggerEl => new bootstrap.Tooltip(tooltipTriggerEl))

function LimparNovaConta()
{
    var form = document.getElementById("formNovaConta");
    form.reset();
}

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