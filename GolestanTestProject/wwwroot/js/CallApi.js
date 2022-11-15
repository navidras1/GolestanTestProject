async function CallApi (model) {
    let vv;
    await axios.post("/General/CallApi", model).then(response => vv = response.data).catch(err => console.log(err));
    return vv;


}