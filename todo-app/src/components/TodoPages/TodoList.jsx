import { React, useState, useEffect } from 'react';
import TodoForm from './TodoForm';
import Todo from './Todo';
import TodoService from '../../services/TodoService';
import './style.css'

function TodoList() {

    const [todos, setTodos] = useState([]);
    let user = localStorage.getItem('loginUser');

    useEffect(() => {
        let todoService = new TodoService();
        todoService.getTodoList().then(result => setTodos(result.data));
    });

    const addTodo = (todo) => {
        if(!todo.text || /^\s*$/.test(todo.text)) {
            return; 
        }

        const newTodos = [todo, ...todos];
        setTodos(newTodos);
    }


    const removeTodo = (id) => {
        const removeArr = [...todos].filter(todo => todo.id !== id);
        setTodos(removeArr);
    }

    const updateTodo = (id, newValue) => {
        if(!newValue.text || /^\s*$/.test(newValue.text)) {
            return; 
        }

        setTodos(prev => prev.map(item => (item.id === id ? newValue : item)))
    };

    const completeTodo = (id) => {
        let updatedTodos = todos.map((todo) => {
            if(todo.id === id) {
                todo.isComplete = !todo.isComplete
            }

            return todo;
        });

        setTodos(updatedTodos);
    };

    return (
        <div className="todo-app">
            <h1>Hello {user} What's the plan for Today ?</h1>
            <TodoForm  onSubmit={addTodo} />
            <Todo todos={todos} completeTodo={completeTodo} removeTodo={removeTodo} updateTodo={updateTodo} />
        </div>
    )
}

export default TodoList