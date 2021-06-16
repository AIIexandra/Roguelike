using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomGeneration : MonoBehaviour
{
    public Room[] roomPrefabs;
    public Room startingRoom;

    private Room[,] spawnedRooms;

    void Start()
    {
        spawnedRooms = new Room[11, 11];
        spawnedRooms[5, 5] = startingRoom;

        for (int i = 0; i < 12; i++)
        {
            GenerationOneRoom();
        }
    }

    void GenerationOneRoom()
    {
        HashSet<Vector2Int> vacantGener = new HashSet<Vector2Int>();

        for (int x = 0; x < spawnedRooms.GetLength(0); x++)
        {
            for (int y = 0; y < spawnedRooms.GetLength(1); y++)
            {
                if (spawnedRooms[x, y] == null) continue;

                int maxX = spawnedRooms.GetLength(0) - 1;
                int maxY = spawnedRooms.GetLength(1) - 1;

                if (x > 0 && spawnedRooms[x - 1, y] == null) vacantGener.Add(new Vector2Int(x - 1, y));
                if (y > 0 && spawnedRooms[x, y - 1] == null) vacantGener.Add(new Vector2Int(x, y - 1));
                if (x < maxX && spawnedRooms[x + 1, y] == null) vacantGener.Add(new Vector2Int(x + 1, y));
                if (y < maxY && spawnedRooms[x, y + 1] == null) vacantGener.Add(new Vector2Int(x, y + 1));
            }
        }

        Room newRoom = Instantiate(roomPrefabs[Random.Range(0, roomPrefabs.Length)]);
        Vector2Int position = vacantGener.ElementAt(Random.Range(0, vacantGener.Count));
        newRoom.transform.position = new Vector3(position.x - 5, 0, position.y - 5) * 30;

        spawnedRooms[position.x, position.y] = newRoom;
    }
}
