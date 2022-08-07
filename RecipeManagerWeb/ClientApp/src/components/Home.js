import React, { Component } from 'react'
import { Link } from 'react-router-dom'
import { NavLink } from 'reactstrap'
import { BsFillPencilFill, BsFillTrashFill } from 'react-icons/bs'

export class Home extends Component {
  static displayName = Home.name

  constructor(props) {
    super(props)
    this.state = { recipes: [], loading: true }
  }

  static renderRecipes(recipes) {
    return (
      <table
        className="table table-striped table-bordered"
        aria-labelledby="tabelLabel"
      >
        <thead>
          <tr>
            <th>Id</th>
            <th>Kategorie</th>
            <th>Name</th>
            <th>Menge</th>
            <th>Einheit</th>
            <th>Zeit</th>
            <th>Vegetarisch</th>
            <th>Aktionen</th>
          </tr>
        </thead>
        <tbody>
          {recipes.map((recipe) => (
            <tr key={recipe.id}>
              <td>{recipe.id}</td>
              <td>{recipe.recipeCategory.name}</td>
              <td>{recipe.title}</td>
              <td>{recipe.amount}</td>
              <td>{recipe.portionUnit}</td>
              <td>{recipe.time}</td>
              <td>
                <input type="checkbox" checked={recipe.vegetarian}></input>
              </td>
              <td class="whitespace-nowrap text-sm">
                <button class="edit-button inline-block px-4 leading-none border rounded ">
                  <BsFillPencilFill />
                </button>
                <button class="inline-block px-4 leading-none border rounded ">
                  <BsFillTrashFill />
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    )
  }

  render() {
    let contents = this.state.loading ? (
      <p>
        <div class="spinner-border" role="status">
          <span class="sr-only"></span>
        </div>
      </p>
    ) : (
      Home.renderRecipes(this.state.recipes)
    )

    return (
      <div>
        <h1 id="tabelLabel">Rezepte</h1>
        <NavLink tag={Link} className="text-dark create-entity" to="/addrecipe">
          Neues Rezept hinzufügen
        </NavLink>
        {contents}
      </div>
    )
  }

  componentDidMount() {
    this.populateRecipes()
  }

  async populateRecipes() {
    const response = await fetch('/api/recipes')
    const data = await response.json()
    this.setState({ recipes: data, loading: false })
  }
}
