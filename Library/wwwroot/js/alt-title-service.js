const selectedAltTitles = new Set();

function addAltTitle(id, tagId, fieldId) {
    const input = document.getElementById(id);
    const title = input.value.trim();

    if (title && !selectedAltTitles.has(title)) {
        selectedAltTitles.add(title);
        updateAltTitleTags(tagId, fieldId);
    }

    input.value = "";
}

function removeAltTitle(title, tagId, fieldId) {
    selectedAltTitles.delete(title);
    updateAltTitleTags(tagId, fieldId);
}

function updateAltTitleTags(tagId, fieldId) {
    const tagContainer = document.getElementById(tagId);
    tagContainer.innerHTML = "";

    [...selectedAltTitles].forEach(title => {
        const tag = document.createElement("div");
        tag.className = "flex items-center bg-blue-100 text-blue-800 px-2 py-1 rounded-full text-sm";
        tag.innerHTML = `
            <span>${title}</span>
            <button type="button" onclick="removeAltTitle('${title}', '${tagId}', '${fieldId}')" class="ml-2 text-blue-600 hover:text-red-600 font-bold">&times;</button>
        `;
        tagContainer.appendChild(tag);
    });

    document.getElementById(fieldId).value = [...selectedAltTitles].join(", ");

    if (selectedAltTitles.size === 0) {
        tagContainer.classList.add('hidden');
    } else {
        tagContainer.classList.remove('hidden');
    }
}