// In-memory storage for users (no localStorage)
let users = [];
let currentUser = null;
let authToken = null;

// Initialize on page load
document.addEventListener('DOMContentLoaded', function () {
    // Set up event listeners
    document.getElementById('loginBtn').addEventListener('click', function (e) {
        e.preventDefault();
        if (currentUser) {
            logout();
        } else {
            openAuthModal('register');
        }
    });

    document.getElementById('startLearningBtn').addEventListener('click', function () {
        if (!currentUser) {
            openAuthModal('register');
        } else {
            alert('Добро пожаловать в академию, ' + currentUser.name + '!');
        }
    });

    // Form submissions
    document.getElementById('registerForm').addEventListener('submit', handleRegister);
    document.getElementById('loginForm').addEventListener('submit', handleLogin);
});

// Open auth modal with specific tab
function openAuthModal(tab) {
    document.getElementById('authModal').style.display = 'block';
    switchTab(tab);
}

// Close modal
function closeModal() {
    document.getElementById('authModal').style.display = 'none';
    clearMessages();
}

// Switch between tabs
function switchTab(tab) {
    // Update tabs
    document.querySelectorAll('.tab').forEach(t => t.classList.remove('active'));
    if (tab === 'register') {
        document.querySelector('.tab:nth-child(1)').classList.add('active');
    } else {
        document.querySelector('.tab:nth-child(2)').classList.add('active');
    }

    // Show correct form
    document.querySelectorAll('.form-container').forEach(f => f.classList.remove('active'));
    document.getElementById(tab + 'FormContainer').classList.add('active');

    clearMessages();
}

// Clear messages
function clearMessages() {
    document.getElementById('registerMessage').style.display = 'none';
    document.getElementById('loginMessage').style.display = 'none';
}

// Handle registration
function handleRegister(e) {
    e.preventDefault();
    const name = document.getElementById('registerName').value;
    const email = document.getElementById('registerEmail').value;
    const password = document.getElementById('registerPassword').value;

    // Check if user already exists
    if (users.some(u => u.email === email)) {
        showMessage('registerMessage', 'Пользователь с такой почтой уже существует!', 'error');
        return;
    }

    // Generate token
    const token = btoa(email + Date.now()).substring(0, 32);

    // Create new user
    const newUser = {
        name: name,
        email: email,
        password: password,
        token: token,
        createdAt: new Date().toISOString()
    };

    users.push(newUser);

    // Log in the new user
    currentUser = newUser;
    authToken = token;

    showMessage('registerMessage', 'Регистрация успешна! Добро пожаловать в академию!', 'success');
    updateAuthUI();
    setTimeout(() => {
        closeModal();
    }, 1500);
}

// Handle login
function handleLogin(e) {
    e.preventDefault();
    const email = document.getElementById('loginEmail').value;
    const password = document.getElementById('loginPassword').value;

    const user = users.find(u => u.email === email && u.password === password);

    if (user) {
        currentUser = user;
        authToken = user.token;
        showMessage('loginMessage', 'Вход выполнен успешно! Добро пожаловать обратно!', 'success');
        updateAuthUI();
        setTimeout(() => {
            closeModal();
        }, 1500);
    } else {
        showMessage('loginMessage', 'Неверная почта или пароль!', 'error');
    }
}

// Logout
function logout() {
    currentUser = null;
    authToken = null;
    updateAuthUI();
}

// Update UI based on auth state
function updateAuthUI() {
    const authNav = document.getElementById('authNav');
    const loginBtn = document.getElementById('loginBtn');

    if (currentUser) {
        loginBtn.innerHTML = `
                    <div class="user-info">
                        <div class="user-avatar">${currentUser.name.charAt(0)}</div>
                        <span>${currentUser.name}</span>
                        <button class="logout-btn" onclick="logout()">Выйти</button>
                    </div>
                `;
    } else {
        loginBtn.innerHTML = '<i class="fas fa-user me-1"></i>Войти';
    }
}

// Show message
function showMessage(elementId, message, type) {
    const element = document.getElementById(elementId);
    element.textContent = message;
    element.className = 'message ' + type;
    element.style.display = 'block';
}

// Close modal when clicking outside
window.onclick = function (event) {
    if (event.target.classList.contains('auth-modal')) {
        closeModal();
    }
}