export async function getJobs(){
    const response = await fetch("http://localhost:5291/api/navjobs");
    if(!response.ok){
        throw new Error("Failed to fetch jobs");
    }
    return response.json();
}