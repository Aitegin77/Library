const input = document.getElementById('genre-search-engine');
const resultsContainer = document.getElementById('genre-list');
const hiddenInput = document.getElementById('Book_GenresId');
const tagContainer = document.getElementById('genre-tags');
const selectedGenres = new Map();

input.addEventListener('input', async () => {
    const term = input.value.trim();
    if (term.length < 2) {
        resultsContainer.innerHTML = '';
        resultsContainer.classList.add('hidden');
        return;
    }

    const response = await fetch(`?handler=Genres&filter=${encodeURIComponent(term)}`);
    if (!response.ok) return;

    const genres = await response.json();

    if (genres.length === 0) {
        resultsContainer.innerHTML = '<div class="p-2 text-gray-500">Ничего не найдено</div>';
        resultsContainer.classList.remove('hidden');
        return;
    }

    resultsContainer.innerHTML = genres.map(c =>
        `<div class="p-2 cursor-pointer hover:bg-blue-100" data-id="${c.id}" data-name="${c.name}">${c.name}</div>`
    ).join('');
    resultsContainer.classList.remove('hidden');

    resultsContainer.querySelectorAll('div[data-id]').forEach(div => {
        div.onclick = () => {
            const id = div.getAttribute('data-id');
            const name = div.getAttribute('data-name');
            addGenre(id, name);
            input.value = '';
            resultsContainer.classList.add('hidden');
        };
    });
});

function addGenre(id, name) {
    if (!selectedGenres.has(id)) {
        selectedGenres.set(id, name);
        updateGenreTags(tagId, fieldId);
    }
}

function removeGenre(id) {
    selectedGenres.delete(id);
    updateGenreTags();
}

function updateGenreTags() {
    tagContainer.innerHTML = "";

    selectedAuthors.forEach((name, id) => {
        const tag = document.createElement("div");
        tag.className = "flex items-center bg-blue-100 text-blue-800 px-2 py-1 rounded-full text-sm";
        tag.innerHTML = `
            <span>${name}</span>
            <button type="button" onclick="removeGenre('${id}')" class="ml-2 text-blue-600 hover:text-red-600 font-bold">&times;</button>
        `;
        tagContainer.appendChild(tag);
    });

    hiddenInput.value = [...selectedGenres.keys()].join(', ');

    if (selectedGenres.size === 0) {
        tagContainer.classList.add('hidden');
    } else {
        tagContainer.classList.remove('hidden');
    }
}