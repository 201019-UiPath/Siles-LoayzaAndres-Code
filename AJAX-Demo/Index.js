
//Uses AJAX technique
function GetPokemon()
{
    let xhr = new XMLHttpRequest();
    let pokemon = {};
    let pokemonInput = document.querySelector('#pokemonInput').value; //query an id by prefixing with #

    //the ready stat of the xhttp object determines the state of the request
    //the arrow function will execute when the xhttp object has a ready connection
    // 0 - uninitialized
    // 1 - loading (server connection established)
    // 2 - loaded (request received by server)
    // 3 - interactive (processing request)
    // 4 - complete (request received)
    xhr.onreadystatechange = function() {
        if (this.readyState == 4 && this.status == 200)
        {
            //JSON.parse is a function that converts the response body to a JS object
            pokemon = JSON.parse(xhr.responseText)
            document.querySelector('.pokemonResult img').setAttribute('src', pokemon.sprites.front_default) //query a class by prefixing with .
            document.querySelectorAll('.pokemonResult caption').forEach((element) => element.remove());
            let caption = document.createElement('caption');
            let pokeName = document.createTextNode(pokemon.forms[0].name);
            caption.appendChild(pokeName);
            document.querySelector('.pokemonResult').appendChild(caption);
            document.querySelector('#pokemonInput').value = '';
        }
    };

    //creates the request: first param is the http method, second is the endpoint, third sets async
    xhr.open('GET', `https://pokeapi.co/api/v2/pokemon/${pokemonInput}`, true); //string interpolation in JS
    xhr.send();
}

//Uses Fetch API
function GetDigimon()
{
    let digiName = document.querySelector('#digimonInput').value;
    //
    fetch(`https://digimon-api.vercel.app/api/digimon/name/${digiName}`)
    .then(response => response.json())
    .then(result => {
        document.querySelector('.digimonResult img').setAttribute('src', result[0].img);
        document.querySelectorAll('.digimonResult caption').forEach((element) => element.remove());
        let caption = document.createElement('caption');
        caption.appendChild(document.createTextNode(result[0].name));
        document.querySelector('.digimonResult').appendChild(caption);
        document.querySelector('#digimonInput').value = '';
    });
}