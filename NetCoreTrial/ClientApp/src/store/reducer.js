import { ADD_PRODUCT, SET_PRODUCTS, ADD_PRODUCTS_TO_VIEW, DELETE_PRODUCT } from './actionTypes';

const initalState = {
    products : []
};

export default  (state = initalState, action) => {
    switch(action.type) {
        case ADD_PRODUCT: 
            state = { ...state, products: [...state.products, action.product] };
        break;

        case SET_PRODUCTS:
            state = {...state, products : action.products }
        break;

        case ADD_PRODUCTS_TO_VIEW:
            state = { ...state, products : [...state.products, ...action.products] }
        break;

        case DELETE_PRODUCT:
            state = { ...state, products: this.state.products.filter(p => p.id != action.productId ) }
        break;
        default:
            break;
    }

    return state;
}