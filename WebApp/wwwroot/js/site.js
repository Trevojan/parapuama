const tooltipTriggerList = document.querySelectorAll('[data-bs-toggle="tooltip"]')
const tooltipList = [...tooltipTriggerList].map(tooltipTriggerEl => new bootstrap.Tooltip(tooltipTriggerEl))

function LimparNovaConta()
{
    var form = document.getElementById("formNovaConta");
    form.reset();
}

function LimparLogin()
{
    document.getElementById("idLogin").textContent = "a";
    document.getElementById("idSenha").textContent = "a";
    document.getElementById("").textContent = "a";
}

function modalLogin()
{
    document.getElementById("bModalLogin").click();
}