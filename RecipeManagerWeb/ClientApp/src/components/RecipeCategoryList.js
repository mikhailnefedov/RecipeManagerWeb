import React, { Component } from 'react'

export class RecipeCategoryList extends Component {
  static displayName = RecipeCategoryList.name

  constructor(props) {
    super(props)
    this.state = { forecasts: [], loading: true }
  }

  componentDidMount() {
    this.populateWeatherData()
  }

  static renderForecastsTable(forecasts) {
    return (
      <table className="table table-striped" aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Id</th>
            <th>Name</th>
            <th>Aktionen</th>
          </tr>
        </thead>
        <tbody>
          {forecasts.map((forecast) => (
            <tr key={forecast.id}>
              <td>{forecast.id}</td>
              <td>{forecast.name}</td>
              <td></td>
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
      RecipeCategoryList.renderForecastsTable(this.state.forecasts)
    )

    return (
      <div>
        <h1 id="tabelLabel">Rezeptkategorien</h1>
        {contents}
      </div>
    )
  }

  async populateWeatherData() {
    const response = await fetch('/api/recipecategories')
    const data = await response.json()
    this.setState({ forecasts: data, loading: false })
  }
}
