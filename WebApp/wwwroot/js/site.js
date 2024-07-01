const tooltipTriggerList = document.querySelectorAll('[data-bs-toggle="tooltip"]')
const tooltipList = [...tooltipTriggerList].map(tooltipTriggerEl => new bootstrap.Tooltip(tooltipTriggerEl))

function LimparNovaConta()
{
    var form = document.getElementById("formNovaConta");
    form.reset();
}

var userId = 0;