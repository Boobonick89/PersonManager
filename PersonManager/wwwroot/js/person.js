
	const editWindow=document.getElementById("editWindow");
	const closeEditButton=document.getElementById("closeEditButton");

	const editId=document.getElementById("editId");
	const editName=document.getElementById("editName");
	const editAge =document.getElementById("editAge");

	const editButtons = document.querySelectorAll(".edit-personbutton");

	 editButtons.forEach(button => {
		button.addEventListener("click", () => {
			editId.value = button.dataset.id;

			editName.value = button.dataset.name;
			editAge.value = button.dataset.age;

			editWindow.showModal();
		});
	});

	closeEditButton.addEventListener("click",() =>
	{
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

