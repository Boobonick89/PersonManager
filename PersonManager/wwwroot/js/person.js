
const editWindow = document.getElementById("editWindow");
const closeEditButton = document.getElementById("closeEditButton");

const editId = document.getElementById("editId");
const editLastName = document.getElementById("editLastName");
const editFirstName = document.getElementById("editFirstName");
const editMiddleName = document.getElementById("editMiddleName");
const editAge = document.getElementById("editAge");

const editButtons = document.querySelectorAll(".edit-personbutton");

editButtons.forEach(button => {
	button.addEventListener("click", () => {
		editId.value = button.dataset.id;

		editLastName.value = button.dataset.lastName;
		editFirstName.value = button.dataset.firstName;
		editMiddleName.value = button.dataset.middleName;
		editAge.value = button.dataset.age;

		editWindow.showModal();
	});
});

closeEditButton.addEventListener("click", () => {
	editWindow.close();
});

const searchWindow = document.getElementById("searchWindow");
const searchButton = document.getElementById("searchButton");
const closeSearchButton = document.getElementById("closeSearchButton");

searchButton.addEventListener("click", () => {
	searchWindow.showModal();
})

closeSearchButton.addEventListener("click", () => {
	searchWindow.close();
})

