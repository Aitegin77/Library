const input = document.getElementById('publisher-search-engine');
const resultsContainer = document.getElementById('publisher-list');
const hiddenInput = document.getElementById('Book_PublisherId');

input.addEventListener('input', async () => {
    const term = input.value.trim();
    if (term.length < 2) {
        resultsContainer.innerHTML = '';
        resultsContainer.classList.add('hidden');
        hiddenInput.value = '';
        return;
    }

    const response = await fetch(`?handler=Publishers&filter=${encodeURIComponent(term)}`);
    if (!response.ok) return;

    const publishers = await response.json();

    if (publishers.length === 0) {
        resultsContainer.innerHTML = '<div class="p-2 text-gray-500">Ничего не найдено</div>';
        resultsContainer.classList.remove('hidden');
        hiddenInput.value = '';
        return;
    }

    resultsContainer.innerHTML = publishers.map(c =>
        `<div class="p-2 cursor-pointer hover:bg-blue-100" data-id="${c.id}">${c.name}</div>`
    ).join('');
    resultsContainer.classList.remove('hidden');

    resultsContainer.querySelectorAll('div').forEach(div => {
        div.onclick = () => {
            input.value = div.textContent;
            hiddenInput.value = div.getAttribute('data-id');
            resultsContainer.classList.add('hidden');
        };
    });
});
