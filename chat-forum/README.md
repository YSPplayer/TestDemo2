# 聊天论坛项目

这是一个使用 Vue.js 开发的聊天论坛网页项目。该项目旨在提供一个用户友好的平台，允许用户进行实时聊天和讨论。

## 项目结构

```
chat-forum
├── public
│   └── index.html          # 应用的主 HTML 文件
├── src
│   ├── main.js             # 应用的入口文件
│   ├── App.vue             # 根组件
│   ├── components           # 组件目录
│   │   ├── ChatRoom.vue     # 聊天房间组件
│   │   ├── MessageList.vue   # 消息列表组件
│   │   ├── MessageInput.vue  # 消息输入组件
│   │   ├── UserList.vue      # 用户列表组件
│   │   └── TopicList.vue     # 话题列表组件
│   ├── views                # 视图目录
│   │   ├── Home.vue         # 主页视图
│   │   ├── Forum.vue        # 论坛视图
│   │   └── ChatDetail.vue   # 聊天详情视图
│   ├── router               # 路由配置目录
│   │   └── index.js         # 路由配置文件
│   ├── store                # 状态管理目录
│   │   └── index.js         # 状态管理文件
│   ├── assets               # 资源目录
│   │   └── styles
│   │       └── main.css     # 全局样式文件
│   └── utils                # 工具函数目录
│       └── index.js         # 工具函数文件
├── package.json             # npm 配置文件
├── vite.config.js           # Vite 配置文件
└── README.md                # 项目文档文件
```

## 安装与运行

1. 克隆项目到本地：
   ```
   git clone <项目地址>
   cd chat-forum
   ```

2. 安装依赖：
   ```
   npm install
   ```

3. 启动开发服务器：
   ```
   npm run dev
   ```

4. 打开浏览器访问 `http://localhost:3000` 查看应用。

## 贡献

欢迎任何形式的贡献！请提交问题或拉取请求。

## 许可证

本项目采用 MIT 许可证。