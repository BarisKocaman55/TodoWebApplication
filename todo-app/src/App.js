import './App.css';
import LoginPage from './components/UserPage/LoginPage';
import RegisterPage from './components/UserPage/RegisterPage';
import TodoList from './components/TodoPages/TodoList';
import { BrowserRouter as Router, Route } from 'react-router-dom';

function App() {
  return (
    <Router>
      <div className="app">
        <Route exact path="/" component={RegisterPage} />
        <Route exact path="/login" component={LoginPage} />
        <Route exact path="/todoList" component={TodoList} />
      </div>
    </Router>
  );
}

export default App;
