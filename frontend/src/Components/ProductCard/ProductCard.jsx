import React from 'react'
import './productcard.css'

const ProductCard = (props) => {
    const handleProductClick = () => {
        window.location.href = `/product/${props.product.productId}`;
    }

  return (
    <div className='product-card' onClick={handleProductClick}>
        <img src={props.product.imageUrl} alt={props.product.name}/>
        <h4>{props.product.name} </h4>
        </div>
  )
}

export default ProductCard