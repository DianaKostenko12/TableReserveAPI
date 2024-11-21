# Table Reserve API

**Table Reserve API** — це RESTful API для управління бронюванням столів у ресторанах. Проект забезпечує зручний інтерфейс для роботи з бронюваннями, столами та користувачами, підтримуючи авторизацію та розмежування прав доступу.

---

## 📌 Основні можливості

### **Auth (Авторизація та реєстрація)**

#### **[POST] /auth/register**  
Реєстрація нового користувача.  
**Вхідні дані:**
```json
{
  "firstName": "string",
  "lastName": "string",
  "userName": "string",
  "email": "user@example.com",
  "password": "string"
}
```
Відповідь:
User created successfully!

#### **[POST] /auth/login**
Авторизація користувача.

**Вхідні дані:**
```json
{
  "userName": "string",
  "password": "securePassword"
}
```
Відповідь:
JWT токен у вигляді рядка.

### **Booking (Бронювання)**

#### **[GET] /booking**
Отримати всі бронювання (доступно лише для ролі Admin).

#### **[GET] /booking/{date}**
Отримати бронювання за певну дату (доступно лише для ролі Admin).

#### **[POST] /booking**
Додати нове бронювання (потребує авторизації).

#### **[DELETE] /booking**
Видалити бронювання за його ID (потребує авторизації).

#### **[GET] /booking/byUserId**
Отримати всі бронювання, створені поточним користувачем (потребує авторизації).

### **Table (Столи)**

#### **[GET] /table**
Отримати всі столи (доступно лише для ролі Admin).

#### **[GET] /table/free-tables**
Отримати доступні (вільні) столи на основі критеріїв пошуку (доступно лише для ролі Admin).

#### **[POST] /table**
Додати новий стіл (доступно лише для ролі Admin).

#### **[DELETE] /table**
Видалити стіл за його ID (доступно лише для ролі Admin).

## 🛠 Технології
- Backend: ASP.NET Core
- Mapping: AutoMapper
- Авторизація: JWT Tokens
- База даних: SQL Server

## 🚀 Встановлення
- Клонуйте репозиторій:
> git clone https://github.com/DianaKostenko12/TableReserveAPI.git

- Перейдіть у директорію проекту:
> cd TableReserveAPI

- Налаштуйте файл appsettings.json для підключення до бази даних.
- Виконайте міграцію бази даних:
> dotnet ef database update -p .\DAL -s .\TableReserveAPI

- Запустіть проект:
> dotnet run

