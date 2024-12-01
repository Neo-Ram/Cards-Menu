document.addEventListener('DOMContentLoaded', () => {
    const tarjetas = document.querySelectorAll('.tarjeta');
    
    // Definimos las URLs para cada tarjeta
    const urls = {
        'tarjeta1': '#pagina1',
        'tarjeta2': '#pagina2',
        'tarjeta3': '#pagina3',
        'tarjeta4': '#pagina4',
        'tarjeta5': '#pagina5'
    };
    
    tarjetas.forEach((tarjeta, index) => {
        tarjeta.addEventListener('click', function() {
            // Añadir clase para la animación
            this.classList.add('girar');
            
            // Ocultar las demás tarjetas
            tarjetas.forEach(t => {
                if (t !== this) {
                    t.style.opacity = '0';
                    t.style.transform = 'translateY(100px)';
                }
            });

            // Redirigir después de que termine la animación
            setTimeout(() => {
                // Obtener la URL correspondiente según el índice de la tarjeta
                const url = urls[`tarjeta${index + 1}`];
                window.location.href = url;
            }, 2000);
        });
    });
});
