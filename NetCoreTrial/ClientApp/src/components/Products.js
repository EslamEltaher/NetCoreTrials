import React, { Component } from 'react';
import * as axios  from 'axios';
import { throws } from 'assert';
import { connect } from 'react-redux';
import { SET_PRODUCTS, ADD_PRODUCT, DELETE_PRODUCT } from '../store/actionTypes';

class Products extends Component {
    constructor(){
        super();
        console.log('CTOR');
    }


    state = {
    //     products : [],
        productToAdd : {
            ImageUrl : "",
            categoryId: 1,
        },
    };

    componentDidMount() {
        axios.default.get('http://localhost:5000/api/Product').then(response => { 
            console.log('before');
            this.props.setProducts(response.data);
            console.log('after');
            // console.log(response)
            // this.setState({ products : response.data })
        });
    }

    static getDerivedStateFromProps(nextProps, prevState){
        if(nextProps.products!==prevState.products){
          return { products: nextProps.products};
        }
        else return null;
      }

    deleteProduct(productId) {
        axios.default.delete('http://localhost:5000/api/Product/' + productId).then(response => { 
            this.props.deleteProduct(response.data);
            // this.setState({ products : this.state.products.filter(p => p.id != response.data) });
        });
    }

    addProduct = () => { 
        axios.default.post('http://localhost:5000/api/Product', this.state.productToAdd).then(response => {
            this.props.addProduct(response.data);
            // this.setState({ products: [...this.state.products, response.data] });
        });
    }
    onInputChange = (event) => {
        console.log(event.target);
        this.setState({ productToAdd: { ...this.state.productToAdd, [event.target.id]: event.target.value } });
        console.log(this.state.productToAdd);
    }

    render() {
        console.log('rendering...');
        return (
        <div>
            <table className="active table table-bordered table-hover table-striped">
                <thead>
                    <tr>
                        <th>ProductId</th>
                        <th>Name</th>
                        <th>Description</th>
                        <th>Price</th>
                        <th>Image</th>
                        <th>Delete</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        this.props.products.map(p => (
                            <tr key={p.id}>
                                <td>{p.id}</td>
                                <td>{p.name}</td>
                                <td>{p.description}</td>
                                <td>{p.price}</td>
                                <td><img alt={p.description} width="300px" height="300px" src={p.imageUrl}/></td>
                                <td><button onClick={() => this.deleteProduct(p.id)} className="btn btn-danger">Delete</button></td>
                            </tr>
                        ))
                    }
                </tbody>
            </table>

            <form /*noValidate*/>
                {/* <div><input type="text" nam e="name" changed={function() { console.log(...arguments)}}/></div> */}

                <div className="form-group">
                    <label htmlFor="Name">Name</label>
                    <input onChange={this.onInputChange} type="text" className="form-control" id="Name" placeholder="Product Name" />
                </div>
                <div className="form-group">
                    <label htmlFor="Description">Description</label>
                    <input onChange={this.onInputChange} type="text" className="form-control" id="Description" placeholder="Product Description" />
                </div>
                <div className="form-group">
                    <label htmlFor="Price">Price</label>
                    <input onChange={this.onInputChange} type="number" className="form-control" id="Price" placeholder="Price" />
                </div>
                <div className="form-group">
                    <button className="form-control btn btn-success" type="button" id="submit" onClick={this.addProduct} >
                        Add
                    </button>
                </div>
                <img width="300px" height="300px" src="https://cf3.s3.souqcdn.com/item/2019/05/20/54/14/89/73/item_L_54148973_8207d64f7f9fd.jpg" />
{/*                 
                <div className="form-group">
                    <label htmlFor="exampleInputEmail1">Email address</label>
                    <input type="email" className="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter email" />
                </div>
                    <small id="emailHelp" className="form-text text-muted">We'll never share your email with anyone else.</small> */}
            </form>
        </div>
        );
    }
};

const mapStateToProps = (state) => {
    return { products : state.products };
}
const mapDispatchToProps = (dispatch) => {
    return { 
        setProducts: products => dispatch({ type : SET_PRODUCTS, products }),
        addProduct: product => dispatch({ type: ADD_PRODUCT , product}),
        deleteProduct: productId => dispatch({type: DELETE_PRODUCT, productId})
    }
}
  


export default connect(mapStateToProps, mapDispatchToProps)(Products);