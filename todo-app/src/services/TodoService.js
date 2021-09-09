import axios from "axios";

export default class TodoService {
    getTodoList() {
        return axios.get("https://localhost:44314/api/Todos/getAll");
    }

    getCompletedTodos() {
        return axios.get("https://localhost:44314/api/Todos/getCompletedTodos");
    }

    getUnCompletedTodos() {
        return axios.get("https://localhost:44314/api/Todos/getUncompletedTodos");
    }

    addTodo(data) {
        axios.post("https://localhost:44314/api/Todos/addTodo", data);
    }

    updateTodo(data) {
        axios.post("https://localhost:44314/api/Todos/updateTodo", data);
    }

    deleteTodo(data) {
        axios.post("https://localhost:44314/api/Todos/deleteTodo", data);
    }
}