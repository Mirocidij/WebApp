import React, { PureComponent } from "react";

let CallbackTimeout: any;

export default class Timer extends PureComponent<{}, { date: Date }> {
  public state = {
    date: new Date()
  }

  componentDidMount(): void {
    CallbackTimeout = setInterval(this.tick, 1000);
  }

  componentWillUnmount(): void {
    clearInterval(CallbackTimeout)
  }

  private tick = () => {
    this.setState({
      date: new Date()
    })
  }
  
  render() {
    return (
      <div>
        <h1>Current time is {this.state.date.toLocaleTimeString()}</h1>
      </div>
    )
  }
}