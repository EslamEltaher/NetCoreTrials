import { createStore, Reducer } from 'redux';
import reducer from './reducer';

export const store = createStore(reducer);