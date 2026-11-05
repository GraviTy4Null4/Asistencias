function updateDateTime() {
    var now = new Date();
    var options = {
        weekday: 'long',
        year: 'numeric',
        month: 'long',
        day: 'numeric',
        hour: '2-digit',
        minute: '2-digit',
        second: '2-digit'
    };
    var formattedDateTime = now.toLocaleDateString('es-ES', options);
    document.getElementById('qwerty').value = formattedDateTime;
}

setInterval(updateDateTime, 1000); // Actualizar cada segundo
updateDateTime(); 