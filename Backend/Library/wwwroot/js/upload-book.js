///*-----------------Genre-----------------*/
////const selectedGenres = new Map();

////function addGenre(id, name, tagId, fieldId, listId) {
////    if (!selectedGenres.has(id)) {
////        selectedGenres.set(id, name);
////        updateGenreTags(tagId, fieldId);
////    }

////    document.getElementById(listId).classList.add("hidden");
////}

////function removeGenre(id, tagId, fieldId) {
////    selectedGenres.delete(id);
////    updateGenreTags(tagId, fieldId);
////}

////function updateGenreTags(tagId, fieldId) {
////    const tagContainer = document.getElementById(tagId);
////    tagContainer.innerHTML = "";

////    selectedGenres.forEach((name, id) => {
////        const tag = document.createElement("div");
////        tag.className = "flex items-center bg-blue-100 text-blue-800 px-2 py-1 rounded-full text-sm";
////        tag.innerHTML = `
////            <span>${name}</span>
////            <button type="button" onclick="removeGenre(${id}, '${tagId}', '${fieldId}')" class="ml-2 text-blue-600 hover:text-red-600 font-bold">&times;</button>
////        `;
////        tagContainer.appendChild(tag);
////    });

////    document.getElementById(fieldId).value = [...selectedGenres.keys()].join(", ");
////}


///*-----------------Author-----------------*/
////const selectedAuthors = new Map();

////function addAuthor(id, name, tagId, fieldId, listId, arrowId) {
////    if (!selectedAuthors.has(id)) {
////        selectedAuthors.set(id, name);
////        updateAuthorTags(tagId, fieldId);
////    }

////    toggleDropdown(listId, arrowId);
////}

////function removeAuthor(id, tagId, fieldId) {
////    selectedAuthors.delete(id);
////    updateAuthorTags(tagId, fieldId);
////}

////function updateAuthorTags(tagId, fieldId) {
////    const tagContainer = document.getElementById(tagId);
////    tagContainer.innerHTML = "";

////    selectedAuthors.forEach((name, id) => {
////        const tag = document.createElement("div");
////        tag.className = "flex items-center bg-blue-100 text-blue-800 px-2 py-1 rounded-full text-sm";
////        tag.innerHTML = `
////            <span>${name}</span>
////            <button type="button" onclick="removeAuthor('${id}', '${tagId}', '${fieldId}')" class="ml-2 text-blue-600 hover:text-red-600 font-bold">&times;</button>
////        `;
////        tagContainer.appendChild(tag);
////    });

////    if (selectedAuthors.size === 0) {
////        tagContainer.classList.add("hidden");
////    } else {
////        tagContainer.classList.remove("hidden");
////    }

////    document.getElementById(fieldId).value = [...selectedAuthors.keys()].join(", ");
////}


///*-----------------AltTitle-----------------*/
//const selectedAltTitles = new Set();

//function addAltTitle(name) {
//    if (!selectedAltTitles.has(name)) {
//        selectedAltTitles.add(name);
//        updateAltTitleTags();
//    }
//}

//function removeAltTitle(name) {
//    selectedAltTitles.delete(name);
//    updateAltTitleTags();
//}

//function updateAltTitleTags(tagId, fieldId) {
//    const tagContainer = document.getElementById(tagId);
//    tagContainer.innerHTML = "";

//    [...selectedAltTitles].forEach(name => {
//        const tag = document.createElement("div");
//        tag.className = "flex items-center bg-blue-100 text-blue-800 px-2 py-1 rounded-full text-sm";
//        tag.innerHTML = `
//            <span>${name}</span>
//            <button type="button" onclick="removeAltTitle('${name}')" class="ml-2 text-blue-600 hover:text-red-600 font-bold">&times;</button>
//        `;
//        tagContainer.appendChild(tag);
//    });

//    document.getElementById(fieldId).value = [...selectedAltTitles].join(", ");
//}

//function saveNewAltTitle(id, modalId) {
//    const input = document.getElementById(id);
//    const name = input.value.trim();
//    if (!name) {
//        alert("Введите название!");
//        return;
//    }

//    addAltTitle(name);
//    closeModal(modalId);
//}


///*-----------------Publisher-----------------*/
////function updatePublisher(id, name, tagId, fieldId, listId) {
////    const tagContainer = document.getElementById(tagId);
////    tagContainer.innerHTML = name;
////    document.getElementById(listId).classList.add("hidden");

////    document.getElementById(fieldId).value = id;
////}


///*-----------------BookType-----------------*/
////function updateBookType(id, name, tagId, fieldId, listId) {
////    const tagContainer = document.getElementById(tagId);
////    tagContainer.innerHTML = name;
////    document.getElementById(listId).classList.add("hidden");

////    document.getElementById(fieldId).value = id;
////}


///*-----------------Others-----------------*/
//function openModal(modal) {
//    document.getElementById(modal).classList.remove("hidden");
//}

//function closeModal(modal) {
//    document.getElementById(modal).classList.add("hidden");
//}

//function toggleDropdown(id, arrowId) {
//    document.getElementById(id).classList.toggle("hidden");
//    document.getElementById(arrowId).classList.toggle('rotate-180');
//}