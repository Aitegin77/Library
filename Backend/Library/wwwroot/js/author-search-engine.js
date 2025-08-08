const input = document.getElementById('author-search-engine');
const resultsContainer = document.getElementById('author-list');
const hiddenInput = document.getElementById('Book_AuthorsId');
const tagContainer = document.getElementById('author-tags');
const selectedAuthors = new Map();

input.addEventListener('input', async () => {
    const term = input.value.trim();
    if (term.length < 2) {
        resultsContainer.innerHTML = '';
        resultsContainer.classList.add('hidden');
        return;
    }

    const response = await fetch(`?handler=Authors&filter=${encodeURIComponent(term)}`);
    if (!response.ok) return;

    const authors = await response.json();

    if (authors.length === 0) {
        resultsContainer.innerHTML = '<div class="p-2 text-gray-500">Ничего не найдено</div>';
        resultsContainer.classList.remove('hidden');
        return;
    }

    resultsContainer.innerHTML = authors.map(c =>
        `<div class="p-2 cursor-pointer hover:bg-blue-100" data-id="${c.id}" data-name="${c.name}">${c.name}</div>`
    ).join('');
    resultsContainer.classList.remove('hidden');

    resultsContainer.querySelectorAll('div[data-id]').forEach(div => {
        div.onclick = () => {
            const id = div.getAttribute('data-id');
            const name = div.getAttribute('data-name');
            addAuthor(id, name);
            input.value = '';
            resultsContainer.classList.add('hidden');
        };
    });
});

function addAuthor(id, name) {
    if (!selectedAuthors.has(id)) {
        selectedAuthors.set(id, name);
        updateAuthorTags();
    }
}

function removeAuthor(id) {
    selectedAuthors.delete(id);
    updateAuthorTags();
}

function updateAuthorTags() {
    tagContainer.innerHTML = "";

    selectedAuthors.forEach((name, id) => {
        const tag = document.createElement("div");
        tag.className = "flex items-center bg-blue-100 text-blue-800 px-2 py-1 rounded-full text-sm";
        tag.innerHTML = `
            <span>${name}</span>
            <button type="button" onclick="removeAuthor('${id}')" class="ml-2 text-blue-600 hover:text-red-600 font-bold">&times;</button>
        `;
        tagContainer.appendChild(tag);
    });

    hiddenInput.value = [...selectedAuthors.keys()].join(', ');

    if (selectedAuthors.size === 0) {
        tagContainer.classList.add('hidden');
    } else {
        tagContainer.classList.remove('hidden');
    }
}
