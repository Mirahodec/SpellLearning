# SpellLearning
Индивидуальный проект по теме: Spell Learning
![Логотип]( "Логотип GitHub")
<p align="center">
  <img src="a79bdfc5ba5156e0096d0dbe44a062c4.png" 
       width="150" 
       alt="Логотип GitHub">
</p>
<!DOCTYPE html>
<html lang="ru">
<head>
  <title>SpellLearning - Magical Card Adventure</title>
  <style>
      * {
          margin: 0;
          padding: 0;
          box-sizing: border-box;
      }
      body {
          font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
          background: linear-gradient(135deg, #0c0c2d 0%, #1a1a4a 100%);
          color: #ffffff;
          line-height: 1.6;
      }
      .container {
          max-width: 1200px;
          margin: 0 auto;
          padding: 20px;
      }
      header {
          text-align: center;
          padding: 40px 0;
          background: linear-gradient(135deg, #6e45e2 0%, #88d3ce 100%);
          border-radius: 15px;
          margin-bottom: 30px;
      }
      h1 {
          font-size: 3.5em;
          margin-bottom: 10px;
          text-shadow: 2px 2px 4px rgba(0,0,0,0.5);
      }
      .subtitle {
          font-size: 1.5em;
          opacity: 0.9;
      }
      section {
          background: rgba(255, 255, 255, 0.1);
          border-radius: 15px;
          padding: 30px;
          margin-bottom: 30px;
          backdrop-filter: blur(10px);
      }
      h2 {
          color: #ff6b6b;
          margin-bottom: 20px;
          font-size: 2em;
          border-bottom: 2px solid #6e45e2;
          padding-bottom: 10px;
      }
      h3 {
          color: #88d3ce;
          margin: 15px 0;
      }
      .features-grid {
          display: grid;
          grid-template-columns: repeat(auto-fit, minmax(300px, 1fr));
          gap: 20px;
          margin-top: 20px;
      }
      .feature-card {
          background: rgba(255, 255, 255, 0.15);
          padding: 20px;
          border-radius: 10px;
          text-align: center;
          transition: transform 0.3s ease;
      }
      .feature-card:hover {
          transform: translateY(-5px);
      }
      .tech-stack {
          display: flex;
          justify-content: space-around;
          flex-wrap: wrap;
          gap: 20px;
      }
      .tech-item {
          background: rgba(255, 255, 255, 0.1);
          padding: 15px;
          border-radius: 10px;
          text-align: center;
          min-width: 150px;
      }
      .gameplay-steps {
          display: grid;
          grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
          gap: 20px;
      }
      .step {
          background: rgba(255, 255, 255, 0.1);
          padding: 20px;
          border-radius: 10px;
          text-align: center;
      }
      .step-number {
          background: #6e45e2;
          width: 40px;
          height: 40px;
          border-radius: 50%;
          display: flex;
          align-items: center;
          justify-content: center;
          margin: 0 auto 15px;
          font-weight: bold;
      }
      footer {
          text-align: center;
          padding: 30px 0;
          margin-top: 50px;
      }
      .magic-text {
          font-size: 1.2em;
          color: #ff6b6b;
          font-style: italic;
      }
      @media (max-width: 768px) {
          h1 {
              font-size: 2.5em;
          }   
          .features-grid {
              grid-template-columns: 1fr;
          }
      }
  </style>
</head>
<body>
    <div class="container">
        <header>
            <h1>🧙‍♂️ SpellLearning</h1>
            <p class="subtitle">Magical Card Adventure</p>
        </header>
        <section>
            <h2>✨ О проекте</h2>
            <p><strong>SpellLearning</strong> - это интерактивная веб-платформа, сочетающая в себе элементы коллекционной карточной игры, кликер-майнинга и платформера с магической тематикой.</p>
        </section>
        <section>
            <h2>🎴 Основные возможности</h2>
            <div class="features-grid">
                <div class="feature-card">
                    <h3>Гэча-система</h3>
                    <p>Коллекционируйте редкие карты заклинаний через систему gacha</p>
                </div>
                <div class="feature-card">
                    <h3>Кликер-майнинг</h3>
                    <p>Зарабатывайте магическую энергию и улучшайте добычу маны</p>
                </div>
                <div class="feature-card">
                    <h3>Экшн-платформер</h3>
                    <p>Сражайтесь с врагами используя собранные заклинания</p>
                </div>
                <div class="feature-card">
                    <h3>Социальные функции</h3>
                    <p>Обмен картами, рейтинги и достижения</p>
                </div>
            </div>
        </section>
        <section>
            <h2>🚀 Технологии</h2>
            <div class="tech-stack">
                <div class="tech-item">
                    <h3>Frontend</h3>
                    <p>React.js / Vue.js</p>
                </div>
                <div class="tech-item">
                    <h3>Backend</h3>
                    <p>ASP.NET Core</p>
                </div>
                <div class="tech-item">
                    <h3>Database</h3>
                    <p>PostgreSQL</p>
                </div>
                <div class="tech-item">
                    <h3>Game Engine</h3>
                    <p>Phaser.js</p>
                </div>
            </div>
        </section>
        <section>
            <h2>🎯 Игровой процесс</h2>
            <div class="gameplay-steps">
                <div class="step">
                    <div class="step-number">1</div>
                    <p>Зарабатывайте ману через кликер-майнинг</p>
                </div>
                <div class="step">
                    <div class="step-number">2</div>
                    <p>Получайте карты через gacha-систему</p>
                </div>
                <div class="step">
                    <div class="step-number">3</div>
                    <p>Составляйте колоду из 5 заклинаний</p>
                </div>
                <div class="step">
                    <div class="step-number">4</div>
                    <p>Сражайтесь в платформере против врагов</p>
                </div>
            </div>
        </section>
        <section>
            <h2>📦 Структура проекта</h2>
            <pre style="background: rgba(255,255,255,0.1); padding: 20px; border-radius: 10px; overflow-x: auto;">
SpellLearning/
├── Client/          # React/Vue фронтенд
├── Server/          # ASP.NET Core API
├── GameCore/        # Игровое ядро на Phaser
├── Database/        # Модели и миграции
└── Docs/           # Документация
            </pre>
        </section>
        <section>
            <h2>🔮 Будущие обновления</h2>
            <ul style="list-style: none; padding: 20px;">
                <li style="margin: 10px 0; padding-left: 20px; position: relative;">
                    <span style="position: absolute; left: 0;">✅</span> PvP режим против других игроков
                </li>
                <li style="margin: 10px 0; padding-left: 20px; position: relative;">
                    <span style="position: absolute; left: 0;">✅</span> Гилды и клановые войны
                </li>
                <li style="margin: 10px 0; padding-left: 20px; position: relative;">
                    <span style="position: absolute; left: 0;">✅</span> Сезонные события
                </li>
                <li style="margin: 10px 0; padding-left: 20px; position: relative;">
                    <span style="position: absolute; left: 0;">✅</span> Мобильное приложение
                </li>
            </ul>
        </section>
        <footer>
            <p class="magic-text">✨ The magic is in your hands! ✨</p>
            <p>Присоединяйтесь к магическому приключению! Станьте могущественным магом и соберите самую сильную колоду заклинаний!</p>
        </footer>
    </div>
</body>
</html>
