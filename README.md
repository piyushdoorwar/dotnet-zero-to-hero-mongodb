# 🧩 Mongo.All – REST & GraphQL with MongoDB in .NET

Welcome to **Mongo.All** – a full-fledged example that showcases how to build both **REST** and **GraphQL** APIs using **MongoDB** in .NET. Whether you're coming from the old-school controller world or exploring modern GraphQL queries, this solution has got your back.

## 📦 Projects Included

This solution includes three separate projects:

### ✅ `Mongo.Service`
- Shared MongoDB setup and logic
- Contains the `Product` model, `MongoDbContext`, settings class, and `ProductService`

### 🌐 `Rest.Api`
- A traditional REST API using ASP.NET Core
- Contains `ProductsController` and standard CRUD endpoints
- Uses `ProductService` from `Mongo.Service`

### 🚀 `GraphQL.Api`
- A GraphQL API powered by [HotChocolate](https://chillicream.com/docs/hotchocolate)
- Contains `Query`, `Mutation`, and GraphQL configuration
- Supports filtering, sorting, pagination via Mongo
- Exposes endpoint at `/graphql` (works with Banana Cake Pop, Altair, etc.)

---

## 🛠️ Getting Started

### 1. Clone the Repo

### 2. MongoDB Setup
- Use [MongoDB Atlas](https://www.mongodb.com/cloud/atlas) (recommended) or local Mongo
- Update `appsettings.json` in both `GraphQL.Api` and `Rest.Api` with your connection string

```json
"MongoDbSettings": {
  "ConnectionString": "your-mongodb-connection-string",
  "DatabaseName": "YourDatabaseName"
}
```

### 3. Run the Projects
You can run either (or both!) APIs via Visual Studio or CLI:

#### REST API
```bash
cd Rest.Api
dotnet run
```
- Example endpoint: `GET /api/products`

#### GraphQL API
```bash
cd GraphQL.Api
dotnet run
```
- GraphQL playground: `https://localhost:<port>/graphql`

---

## 💡 Sample Queries

### 🔍 GraphQL – Fetch Products
```graphql
query {
  products(page: 1, pageSize: 5) {
    id
    name
    price
  }
}
```

### ➕ GraphQL – Add Product
```graphql
mutation {
  addProduct(input: {
    id: "5f1a7a5e1d1f362017403501",
    name: "Wireless Mouse",
    price: 29.99,
  }) {
    id
    name
    price
  }
}
```

---

## 💬 Why This Project?

I built this to learn and demonstrate how both REST and GraphQL can play nicely with MongoDB in .NET. Sometimes you want structured control (REST), and other times you want the power and flexibility of GraphQL. This repo is proof that you can have both.

---

## 🤝 Contributions

Pull requests are welcome! Open an issue to discuss what you’d like to improve.

---

## 📚 Related Articles

> 👉 [Read the full guide on Medium ](https://medium.com/@piyushdoorwar/a-net-devs-guide-to-mongodb-step-by-step-setup-crud-apis-interview-prep-bca931ac39d5))

---

## 📜 License

MIT – use it freely for learning or production.
