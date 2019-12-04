import React, { Component } from 'react';
import { Route, Router } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import Products from './components/Products';
// import { connect } from 'react-redux';
// import { SET_PRODUCTS, ADD_PRODUCT, DELETE_PRODUCT } from './store/actionTypes';

class App extends Component {
  displayName = App.name
  
  // shouldComponentUpdate(nextProps, nextState) {
  //   for(let prop in nextProps) {
  //     if(prop != 'products' && nextProps[prop] !== this.props[prop])
  //       return true;
  //   }
  //   return false;
  // }

  render() {
    console.log('APP RENDER')
    return (
      // <Router>
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/fetchdata' component={FetchData} />
        <Route path='/Products' component={() => (
          <Products store={this.props.store} setProducts={this.props.setProducts} 
            products={this.props.products}
            addProduct={this.props.addProduct}
            deleteProduct={this.props.deleteProduct} />)}
        />
      </Layout>
      // </Router>
    );
  }
}

// export default connect(mapStateToProps, mapDispatchToProps)(App);
export default App;