'use strict';
function FriendlyChat() {
    this.messageList = document.getElementById('chat_fullscreen');
    this.messageInput = document.getElementById('message');
    this.messageForm = document.getElementById('message-form');
    this.submitButton = document.getElementById('fab_send');
    var buttonTogglingHandler = this.toggleButton.bind(this);
    this.messageForm.addEventListener('submit', this.saveMessage.bind(this));
    this.initFirebase();
}
FriendlyChat.prototype.initFirebase = function () {
    this.auth = firebase.auth();
    this.database = firebase.database();
    this.storage = firebase.storage();
    this.loadMessages();
};
FriendlyChat.prototype.saveImageMessage = function (event) {
    var file = event.target.files[0];

    // Clear the selection in the file picker input.
    this.imageForm.reset();

    // Check if the file is an image.
    if (!file.type.match('image.*')) {
        alert('You can only share images');
        return;
    }
    var customer_name = $('#hdnCustomerName').val();
    var customer_id = $('#hdnCustomerId').val();
    this.messagesRef.push({
        customer_id: customer_id,
        customer_name: customer_name,
        admin_id: 1,
        admin_name: 'Customer Support',
        message: this.messageInput.value,
        sender:'customer',
        imageUrl: FriendlyChat.LOADING_IMAGE_URL
        }).then(function (data) {
            // Upload the image to Firebase Storage.
            this.storage.ref(currentUser.uid + '/' + Date.now() + '/' + file.name)
                .put(file, { contentType: file.type })
                .then(function (snapshot) {
                    // Get the file's Storage URI and update the chat message placeholder.
                    var filePath = snapshot.metadata.fullPath;
                    data.update({ imageUrl: this.storage.ref(filePath).toString() });
                }.bind(this)).catch(function (error) {
                    console.error('There was an error uploading a file to Firebase Storage:', error);
                });
        }.bind(this));
};
FriendlyChat.prototype.loadMessages = function () {
    this.messagesRef = this.database.ref('Customer_Admin');
    this.messagesRef.off();
    var customer_name = $('#hdnCustomerName').val();
    var customer_id = $('#hdnCustomerId').val();
    var setMessage = function (data) {
        var val = data.val();
        if (val.customer_id == customer_id && val.admin_id == 1) {
            if (val.sender == 'customer') {
                this.displayMessage(data.key, val.message, val.customer_name, 'R');
            } else {
                this.displayMessage(data.key, val.message, val.customer_name, 'L');
            }
        }        
    }.bind(this);
    this.messagesRef.limitToLast(20).on('child_added', setMessage);
    this.messagesRef.limitToLast(20).on('child_changed', setMessage);
};
FriendlyChat.prototype.saveMessage = function (e) {
    e.preventDefault();
    if (this.messageInput.value) {
        var customer_name = $('#hdnCustomerName').val();
        var customer_id = $('#hdnCustomerId').val();
        this.messagesRef.push({
            customer_id: customer_id,
            customer_name: customer_name,
            admin_id: '1',
            admin_name: 'Customer Support',
            message: this.messageInput.value,
            sender:'customer'
        }).then(function () {
            FriendlyChat.resetMaterialTextfield(this.messageInput);
            this.toggleButton();
        }.bind(this)).catch(function (error) {
            console.error('Error writing new message to Firebase Database', error);
        });
    }
};
FriendlyChat.resetMaterialTextfield = function (element) {
    element.value = '';
    element.parentNode.MaterialTextfield.boundUpdateClassesHandler();
};
FriendlyChat.prototype.displayMessage = function (key, message, name, align) {
    var div = document.getElementById(key);
    if (!div) {
        var container = document.createElement('div');
        if (align == 'R') {
            container.innerHTML = '<span class="chat_msg_item chat_msg_item_user">' + message + '</span><span class="status2">' + name + '</span>';
        } else {
            container.innerHTML = '<span class="chat_msg_item chat_msg_item_admin">' + message + '</span><span class="status2">' + name + '</span>';
        }
        div = container.firstChild;
        div.setAttribute('id', key);
        this.messageList.appendChild(div);
    }
    setTimeout(function () { div.classList.add('visible') }, 1);
    this.messageList.scrollTop = this.messageList.scrollHeight;
    this.messageInput.focus();
};
FriendlyChat.prototype.toggleButton = function () {
    if (this.messageInput.value) {
        this.submitButton.removeAttribute('disabled');
    } else {
        this.submitButton.setAttribute('disabled', 'true');
    }
};
window.onload = function () {
    window.friendlyChat = new FriendlyChat();
};
