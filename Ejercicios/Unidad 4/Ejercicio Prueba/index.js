const form = document.getElementById('myForm');
const resultDiv = document.getElementById('pokemonDiv');

form.addEventListener('submit', async (event) => {
    event.preventDefault(); // Evitar el envío del formulario

    const id = document.getElementById('pokemonId').value;
    const url = `https://pokeapi.co/api/v2/pokemon/${id}`; // URL de la API

    try {
        const response = await fetch(url);
        if (!response.ok) {
            throw new Error('Pokémon no encontrado');
        }
        const data = await response.json();
        resultDiv.innerHTML = `<h2>${data.name}</h2><img src="${data.sprites.front_default}" alt="${data.name}">`;
    } catch (error) {
        resultDiv.innerHTML = `<p>${error.message}</p>`;
    }
});