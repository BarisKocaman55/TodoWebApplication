import axios from 'axios';
import { React, useState, useEffect, useRef } from 'react';
import TodoService from '../../services/TodoService';

function TodoForm(props) {

    const [input, setInput] = useState(props.edit ? props.edit.value : '');
    const inputRef = useRef(null);
    const [index, setIndex] = useState(0);

    useEffect(() => {
        inputRef.current.focus();
    });

    const handleChange = (event) => {
        setInput(event.target.value);
    };

    const handleSubmit = (event) => {
        event.preventDefault();

        props.onSubmit({
            id : Math.floor(Math.random()* 1000),
            text : input
        });

        setInput('');
    };

    const handleSubmition = (event) => {
        event.preventDefault();
        props.onSubmit({
            id : index,
            text : input
        })
        
        axios.post("http://localhost:8080/api/Todos/addTodo", input)
        .then(response => {
            console.log(response);
        })

        setIndex(index + 1);
        setInput('');
    }; 

    return (
        <div>
            <form className="todo-form" onSubmit={handleSubmit}>
                <input 
                    type="text"
                    className='todo-input'
                    name="text"
                    placeholder="Add todo ..."
                    value={input}
                    onChange={handleChange}
                    ref = {inputRef}
                    />

                <button onClick={handleSubmition} className="todo-button">Add todo</button> 
            </form>
        </div>
    )
}

export default TodoForm