import React, { Component } from 'react'
import { Link } from 'react-router-dom'
import { NavLink } from 'reactstrap'
import { BsFillPencilFill, BsFillTrashFill } from 'react-icons/bs'
import './styles.css'

export class RecipeCategoryList extends Component {
  static displayName = RecipeCategoryList.name

  constructor(props) {
    super(props)
    this.state = { categories: [], loading: true }
  }

  componentDidMount() {
    this.populateCategories()
  }

  static renderCategories(categories) {
    return (
      <table
        className="table table-striped table-bordered"
        aria-labelledby="tabelLabel"
      >
        <thead>
          <tr>
            <th>Id</th>
            <th>Name</th>
            <th>Aktionen</th>
          </tr>
        </thead>
        <tbody>
          {categories.map((category) => (
            <tr key={category.id}>
              <td>{category.id}</td>
              <td>{category.name}</td>
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
      RecipeCategoryList.renderCategories(this.state.categories)
    )

    return (
      <div>
        <h1 id="tabelLabel">Rezeptkategorien</h1>
        <NavLink
          tag={Link}
          className="text-dark create-entity"
          to="/addrecipecategory"
        >
          Neue Kategorie hinzufügen
        </NavLink>
        {contents}
      </div>
    )
  }

  async populateCategories() {
    const response = await fetch('/api/recipecategories')
    const data = await response.json()
    this.setState({ categories: data, loading: false })
  }
}
