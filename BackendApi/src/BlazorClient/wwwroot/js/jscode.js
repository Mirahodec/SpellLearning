// Update current time and date (for users page)
function updateDateTime() {
    const now = new Date();
    const currentTimeElement = document.getElementById('currentTime');
    const currentDateElement = document.getElementById('currentDate');

    if (currentTimeElement && currentDateElement) {
        currentTimeElement.textContent = now.toLocaleTimeString('ru-RU');
        currentDateElement.textContent = now.toLocaleDateString('ru-RU');
    }
}

// Initialize time and date if elements exist
if (document.getElementById('currentTime') || document.getElementById('currentDate')) {
    updateDateTime();
    setInterval(updateDateTime, 1000);
}

// Create magic particles
function createMagicParticles() {
    const particlesContainer = document.getElementById('particles');
    if (!particlesContainer) return;

    const particleCount = 30;

    for (let i = 0; i < particleCount; i++) {
        const particle = document.createElement('div');
        particle.className = 'particle';
        particle.style.left = Math.random() * 95 + 'vw';
        particle.style.animationDelay = Math.random() * 12 + 's';
        particle.style.animationDuration = (8 + Math.random() * 15) + 's';
        particlesContainer.appendChild(particle);
    }
}

// Initialize particles
createMagicParticles();

// Add hover effects to spell cards and mage rows
document.addEventListener('DOMContentLoaded', function () {
    // Spell card hover effects
    const spellCards = document.querySelectorAll('.spell-card');
    spellCards.forEach(card => {
        card.addEventListener('mouseenter', () => {
            card.style.transform = 'translateY(-10px)';
        });
        card.addEventListener('mouseleave', () => {
            card.style.transform = 'translateY(0)';
        });
    });
});