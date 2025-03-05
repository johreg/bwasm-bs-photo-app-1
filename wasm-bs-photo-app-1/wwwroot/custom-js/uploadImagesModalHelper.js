window.closeImageUploadModal = () => {
    var modalElement = document.getElementById('staticBackdrop');
   // console.log(modalElement); 
   // console.log(bootstrap.Modal.getInstance(modalElement)); 
    if (modalElement) {
        var modal = bootstrap.Modal.getInstance(modalElement);
        if (modal) {
            modal.hide();
        }
    }
};
