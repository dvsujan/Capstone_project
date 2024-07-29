import React, { useState } from 'react'
import './cartcard.css'

const CartCard = (props) => {  
    const [cartItem , setCartItem] = useState({
    "productId": 4,
    "name": "Featured Blonde Roast",
    "description": "Featured Blonde Roast",
    "calories": 5,
    "cost": 625,
    "imageUrl": "https://globalassets.starbucks.com/digitalassets/products/bev/Veranda_Blend_Hot.jpg",
    "selectedOptions": [
      {
        "optionId": 20,
        "optionName": "Espesso (2)",
        "optionCost": 10
      }
    ],
    "quantity": 5
  }); 

  return (
    <div> 
        <div className="cart-card">
            <div className='cart-card-img'>
                <img src={cartItem.imageUrl} alt="" />
            </div>
            <div className="cart-card-info">
                <h3>{cartItem.name}</h3>
                <p>{cartItem.description}</p>
                <p>Quantity: {cartItem.quantity}</p>
                <p>Cost: {cartItem.cost}</p>
                <button>Delete</button>
            </div>
        </div>

    </div>
  )
}

export default CartCard