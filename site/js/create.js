function createPessoa(){
    const primeiroNome = document.getElementById ("firstName").value;
    const nomeMeio = document.getElementById("middleName").value;
    const ultimoNome = document.getElementById("lastName").value;
    const cpf = document.getElementById("cpf" ).value;

    const data={

        primeiroNome:primeiroNome,
        nomeMeio :nomeMeio,
        ultimoNome:ultimoNome,
        cpf:cpf 


    }
    

fetch('https://localhost:7043/api/Pessoas/Create', {
    method:'POST',
    headers: {
        'Content-Type':'application/json'
    },
    body:JSON.stringify(data)

}).then(Response =>{
    if(!Response.ok){
        alert("erro ao criar pessoa")
    }
    alert("pessoa criada com sucesso!");
    window.location.href = '../index.html';




})
}