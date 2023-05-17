import React, { useEffect, useState } from 'react';
import logo from './logo.svg';
import './index.css';
import TranslationJobDashboard from './TranslationJobDashboard';
import TranslationJobDto from './Models/TranslationJobDto';
import { fetchAllJobs } from './api/apiEndpoints';
import CreateTranslationJob from './CreateTranslationJob';

function App() {
  const [data, setData] = useState<TranslationJobDto[]>([]);

  const reloadData = async () => {
    setData(await fetchAllJobs());
  }
  useEffect(() => {
    reloadData();
  },  []);

  return (
    <div className="App">
      <h1>Translation jobs</h1>
      <h2>Create new</h2>
      <CreateTranslationJob onCreated={reloadData} />
      <h2>Dashboard</h2>
      <TranslationJobDashboard data={data} />
      
    </div>
  );
}

export default App;
