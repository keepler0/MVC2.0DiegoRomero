function Delete(url, id,name)
{
	Swal.fire({
		title: `Are you sure you want to delete ${name}?`,
		text: "You won't be able to revert this!",
		icon: "warning",
		showCancelButton: true,
		confirmButtonColor: "#3085d6",
		cancelButtonColor: "#d33",
		confirmButtonText: "Yes, delete it!"
	}).then((result) => {
		if (result.isConfirmed) {
			$.ajax({
				url: url,
				type: 'DELETE',
				success: function (data) {
					if (data.success) {
						toastr.success(data.message);
						var row = document.getElementById(id);
						row.remove();
					} else {
						toastr.error(data.message);
					}
				}
			})
		}
	});
}